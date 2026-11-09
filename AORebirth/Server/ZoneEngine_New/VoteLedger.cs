internal sealed class VoteLedger
{
    private const int RequiredVotes = 2;
    private readonly HashSet<string> voters = new(StringComparer.Ordinal);

    public void CastVote(string voter) => voters.Add(voter);

    public bool HasQuorum() => voters.Count > RequiredVotes;
}
