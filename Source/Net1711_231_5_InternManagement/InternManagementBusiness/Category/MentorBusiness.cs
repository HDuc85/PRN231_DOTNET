using InternManagementCommon;
using InternManagementData;
using InternManagementData.Models;

namespace InternManagementBusiness.Category
{
  public class MentorBusiness
  {
    private readonly UnitOfWork _unitOfWork;
    public MentorBusiness()
    {
      _unitOfWork ??= new UnitOfWork();
    }
    public async Task<IInternManagementResult> GetAll()
    {
      try
      {
        var mentors = await _unitOfWork.InternRepository.GetAllAsync();
        if (mentors == null)
          return new BaseResult(Const.WARNING_NO_DATA, "No Mentor data");
        else
          return new BaseResult(Const.SUCCESS_GET, "Get Mentor list success", mentors);
      }
      catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }

    }

    public async Task<IInternManagementResult> GetById(int id)
    {
      try
      {
        if (id == null)
          return new BaseResult(Const.ERROR_EXCEPTION, "Mentor code can not be null");
        var mentor = await _unitOfWork.InternRepository.GetByIdAsync(id);

        if (mentor == null)
          return new BaseResult(Const.WARNING_NO_DATA, "No Mentor data by code");
        else
          return new BaseResult(Const.SUCCESS_GET, "Get Mentor success", mentor);
      }
      catch (Exception ex)
      {
        return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
      }
    }

    public async Task<IInternManagementResult> Create(MentorProfile mentorProfile)
    {
      try
      {
        if (mentorProfile == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Mentor profile cannot be null.");
        }
        if (await _unitOfWork.MentorRepository.CreateAsync(mentorProfile) > 0)
          return new BaseResult(Const.SUCCESS_GET, "Create Mentor success", mentorProfile);
        else
          return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
      }
      catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
    }

    public async Task<IInternManagementResult> Update(MentorProfile mentorProfile)
    {
      try
      {
        MentorProfile mentor = await _unitOfWork.MentorRepository.GetByIdAsync(mentorProfile.MentorId);
        if (mentor == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Mentor profile cannot be found.");
        }
        await _unitOfWork.MentorRepository.UpdateAsync(mentorProfile);
        return new BaseResult(Const.SUCCESS_GET, "Update Mentor success", mentorProfile);
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
        MentorProfile mentor = await _unitOfWork.MentorRepository.GetByIdAsync(id);
        if (mentor == null)
        {
          return new BaseResult(Const.ERROR_EXCEPTION, "Mentor profile cannot be found.");
        }
        await _unitOfWork.MentorRepository.RemoveAsync(mentor);
        return new BaseResult(Const.WARNING_NO_DATA, "Delete Mentor success");
      }
      catch (Exception ex)
      {
        return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
      }
    }
  }
}
