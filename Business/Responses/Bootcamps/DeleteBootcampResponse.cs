namespace Business.Responses.Bootcamps
{
    public class DeleteBootcampResponse
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BootcampStateId { get; set; }

        public DateTime DeletedDate { get; set; }
    }

}
