using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Politics.Model;
using Politics.Data.Infrastructure;

namespace Politics.Service
{
    public interface IRegionService
    {
        void CreateRegion(Region region, int parentId);

        Region GetRegion(int id);
        Region GetRootRegion();
        void DeleteRegion(int id);
    }

    public class RegionService : IRegionService
    {
        IRegionRepository regionsRepository;

        IUnitOfWork unitOfWork;

        public RegionService(IRegionRepository regionsRepository, IUnitOfWork unitOfWork)
        {
            this.regionsRepository = regionsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateRegion(Region region, int parentId)
        {
            var parent = regionsRepository.GetByID(parentId);
            if (parent != null)
            {
                region.Parent = parent;
                regionsRepository.Add(region);
                unitOfWork.Commit();
            }
            else
                throw new RegionIsNotExistException(parentId);
        }

        public void DeleteRegion(int id)
        {
            var toDeleting = regionsRepository.GetByID(id);
            if (toDeleting != null)
            {
                regionsRepository.Delete(toDeleting);
                unitOfWork.Commit();
            }
            else
                throw new RegionIsNotExistException(id);
        }

        public Region GetRegion(int id)
        {
            var region = regionsRepository.GetByID(id);
            if (region != null)
                return region;
            else
                throw new RegionIsNotExistException(id);
        }

        public Region GetRootRegion()
        {
            return GetRegion(1);
        }
    }
}
