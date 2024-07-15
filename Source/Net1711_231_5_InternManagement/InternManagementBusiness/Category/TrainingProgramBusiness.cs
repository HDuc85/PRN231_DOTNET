using InternManagementCommon;
using InternManagementData;
using InternManagementData.Models;

namespace InternManagementBusiness.Category
{
  public class ProgramBusiness
  {
    private readonly UnitOfWork _unitOfWork;
    public ProgramBusiness()
    {
      _unitOfWork ??= new UnitOfWork();
    }

    public async Task<IInternManagementResult> GetAll()
    {
      try
      {
        var mentors = await _unitOfWork.TrainingProgramRepository.GetAllAsync();
        if (mentors == null)
          return new BaseResult(Const.WARNING_NO_DATA, "No Program data");
        else
          return new BaseResult(Const.SUCCESS_GET, "Get Program list success", mentors);
      }
      catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
    }

    public async Task<IInternManagementResult> GetById(int id)
    {
      try
      {
        if (id == null)
          return new BaseResult(Const.ERROR_EXCEPTION, "Program code can not be null");
        var mentor = await _unitOfWork.TrainingProgramRepository.GetByIdAsync(id);

        if (mentor == null)
          return new BaseResult(Const.WARNING_NO_DATA, "No Program data by code");
        else
          return new BaseResult(Const.SUCCESS_GET, "Get Program success", mentor);
      }
      catch (Exception ex)
      {
        return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
      }
    }

    public async Task<IInternManagementResult> Create(TrainingProgram program)
    {
      try
      {
        if (program == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Program profile cannot be null.");
        }
        if (await _unitOfWork.TrainingProgramRepository.CreateAsync(program) > 0)
          return new BaseResult(Const.SUCCESS_GET, "Create Program success", program);
        else
          return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
      }
      catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
    }

    public async Task<IInternManagementResult> Update(TrainingProgram programUpdate)
    {
      try
      {
        TrainingProgram program = await _unitOfWork.TrainingProgramRepository.GetByIdAsync(programUpdate.ProgramId);
        if (program == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Program profile cannot be found.");
        }
        await _unitOfWork.TrainingProgramRepository.UpdateAsync(programUpdate);
        return new BaseResult(Const.SUCCESS_GET, "Update Program success", programUpdate);
      }
      catch (Exception ex)
      {
        return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
      }
    }

    public async Task<IInternManagementResult> Remove(int id)
    {
      try
      {
        TrainingProgram program = await _unitOfWork.TrainingProgramRepository.GetByIdAsync(id);
        if (program == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Program cannot be found.");
        }
        await _unitOfWork.TrainingProgramRepository.RemoveAsync(program);
        return new BaseResult(Const.WARNING_NO_DATA, "Delete Program success");
      }
      catch (Exception ex)
      {
        return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
      }
    }
  }
}
