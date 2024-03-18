namespace Volcafe.Core.Entities;

public class ContractDetailDTO
{
    public string ContractId { get; set; }

    public DateOnly ContractDate { get; set; }

    public string AgentId { get; set; }

    public string ContractSummary { get; set; }

    public int? Quantity { get; set; }

    public string EntityCode { get; set; }

    public DateOnly DeliveryStartDate { get; set; }

    public DateOnly DeliveryEndDate { get; set; }

    public DateOnly ContractApprovedDate { get; set; }

    public string Reviewer { get; set; }

    public int StatusId { get; set; }

    public string Status { get; set; }

    public DateOnly? CreatedDate { get; set; }

}