using Google.Protobuf.Collections;
using Grpc.Core;

namespace DemoGrpc.Services.Team;

public class TeamService : TeamServiceContract.TeamServiceContractBase
{
    public override Task<TeamReply> CreateTeam(CreateTeamRequest request, ServerCallContext context)
    {
        return base.CreateTeam(request, context);
    }

    public override Task<TeamReply> GetTeam(GetTeamRequest request, ServerCallContext context)
    {
        return Task.FromResult<TeamReply>(new TeamReply
        {
            Id = request.Id,
            Name = $"Team-{request.Id}",
            Confederation = $"Confederation-{request.Id}"
        });
    }

    public override Task<TeamListReply> GetTeamList(GetTeamListRequest request, ServerCallContext context)
    {
        var reply = new TeamListReply();

        reply.Teams.AddRange(new RepeatedField<TeamReply>
        {
            new TeamReply
            {
                Id = 1,
                Name = $"Team-{1}",
                Confederation = $"Confederation-{1}"
            },
            new TeamReply
            {
                Id = 1,
                Name = $"Team-{1}",
                Confederation = $"Confederation-{1}"
            },
        });

        return Task.FromResult<TeamListReply>(reply);
    }
}