if (args.Length != 1 || args[0] != "--verify-vote-quorum") return 2;
var ledger = new VoteLedger();
if (ledger.HasQuorum()) return Fail("zero votes reached quorum");
ledger.CastVote("first");
if (ledger.HasQuorum()) return Fail("one vote reached quorum");
ledger.CastVote("first");
if (ledger.HasQuorum()) return Fail("a duplicate vote reached quorum");
ledger.CastVote("second");
if (!ledger.HasQuorum()) return Fail("two distinct votes did not reach quorum");
ledger.CastVote("third");
if (!ledger.HasQuorum()) return Fail("three distinct votes lost quorum");
Console.WriteLine("VOTE_QUORUM_REGRESSION_PASS");
return 0;

static int Fail(string reason)
{
    Console.Error.WriteLine("VOTE_QUORUM_REGRESSION_FAIL: " + reason);
    return 1;
}
