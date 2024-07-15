using InternManagementBusiness.GraphQL;
using InternManagementData.Models;

namespace InternManagementWebAPI.GraphQL
{
    public class Query
    {
        // Intern
        [UseSorting]
        [UseFiltering]
        [UseProjection]
        public async Task<IQueryable<InternProfile>> GetInternList([Service] InternGraphQLBusiness internGraphQLBusiness) => (IQueryable<InternProfile>)await internGraphQLBusiness.GetAllIntern();

        // Mentor
        [UseSorting]
        [UseFiltering]
        [UseProjection]
        public IQueryable<MentorProfile> GetMentorList() => new List<MentorProfile>().AsQueryable();

        // Training Program
        [UseSorting]
        [UseFiltering]
        [UseProjection]
        public IQueryable<TrainingProgram> GetProgramList() => new List<TrainingProgram>().AsQueryable();
    }
}
