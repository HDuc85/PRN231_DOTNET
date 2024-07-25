using InternManagementData.Models;
using InternManagementData.Repository;

namespace InternManagementData
{
    public class UnitOfWork
    {
        private Net17112315InternManagementContext _unitOfWorkContext;
        private InternRepository _intern;
        private MentorRepository _mentor;
        private TrainingProgramRepository _trainingProgram;
        private TaskRepository _taskRepository;
        private JobboardProfileRepository _jobboardProfile;
        private CertificateRepository _certificate;

        public UnitOfWork()
        {

        }


        public InternRepository InternRepository
        {
            get
            {
                return _intern ??= new InternRepository();
            }
        }
        public TrainingProgramRepository TrainingProgramRepository
        {
            get
            {
                return _trainingProgram ??= new TrainingProgramRepository();
            }
        }
        public MentorRepository MentorRepository
        {
            get
            {
                return _mentor ??= new MentorRepository();
            }
        }
        public TaskRepository TaskRepository
        {
            get
            {
                return _taskRepository ??= new TaskRepository();
            }
        }

        public JobboardProfileRepository JobboardProfileRepository
        {
            get
            {
                return _jobboardProfile ??= new JobboardProfileRepository();
            }
        }
        public CertificateRepository CertificateRepository
        {
            get
            {
                return _certificate ??= new CertificateRepository();
            }
        }

        public int SaveChagngesWithTransaction()
        {
            int returnValue = 1;
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    _unitOfWorkContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    returnValue = -1;
                    dbContextTransaction.Rollback();
                }
            }
            return returnValue;
        }
        public async Task<bool> SaveChagngesWithTransactionAsync()
        {
            bool returnValue = true;
            using (var dbContextTransaction = await _unitOfWorkContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _unitOfWorkContext.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    returnValue = false;
                    await dbContextTransaction.RollbackAsync();
                }
            }
            return returnValue;
        }






        
    } 
}

