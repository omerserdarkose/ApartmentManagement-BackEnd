using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.Block;

namespace ApartmentManagement.Business.Abstract
{
    public interface IBlockService
    {
        IDataResult<List<BlockViewDto>> GetAll();
        IResult Add(BlockAddDto blockAddDto);
        IResult Update(BlockUpdateDto updateBlockDto);
        IResult Delete(int blockId);

    }
}
