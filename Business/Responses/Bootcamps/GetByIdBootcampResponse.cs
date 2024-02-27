namespace Business.Responses.Bootcamps
{
    public class GetByIdBootcampResponse
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BootcampStateId { get; set; }
    }

}
