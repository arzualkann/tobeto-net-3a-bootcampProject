namespace Business.Responses.Applications
{
    public class DeleteApplicationResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public DateTime DeletedDate { get; set; }
    }

}
