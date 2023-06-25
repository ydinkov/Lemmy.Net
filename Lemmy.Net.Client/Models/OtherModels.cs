namespace Lemmy.Net.Client.Models;

public class ApproveRegistrationApplication
{
    public bool Approve { get; set; }
    public string? DenyReason { get; set; }
    public int Id { get; set; }
}

public class BanFromCommunity
{
    public bool Ban { get; set; }
    public int CommunityId { get; set; }
    public int? Expires { get; set; }
    public int PersonId { get; set; }
    public string? Reason { get; set; }
    public bool? RemoveData { get; set; }
}

public class BanPerson
{
    public bool Ban { get; set; }
    public int? Expires { get; set; }
    public int PersonId { get; set; }
    public string? Reason { get; set; }
    public bool? RemoveData { get; set; }
}

public class BlockCommunity
{
    public bool Block { get; set; }
    public int CommunityId { get; set; }
}



public class ChangePassword
{
    public string NewPassword { get; set; } = string.Empty;
    public string NewPasswordVerify { get; set; } = string.Empty;
    public string OldPassword { get; set; } = string.Empty;
}
