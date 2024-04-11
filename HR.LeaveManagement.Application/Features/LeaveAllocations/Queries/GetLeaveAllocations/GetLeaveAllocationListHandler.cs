using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocations;

public class GetLeaveAllocationListHandler : IRequestHandler
    <GetLeaveAllocationListQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _repo;
    private readonly IMapper _mapper;

    public GetLeaveAllocationListHandler(
        ILeaveAllocationRepository repo, IMapper mapper)
    {
        this._repo = repo;
        this._mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _repo.GetLeaveAllocationsWithDetails();
        var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        throw new NotImplementedException();
    }
}
