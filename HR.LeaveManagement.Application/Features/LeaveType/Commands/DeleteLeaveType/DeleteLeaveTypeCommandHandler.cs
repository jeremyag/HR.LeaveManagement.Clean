using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Exceptions;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // Verify that record exists
        if(leaveTypeToDelete == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
        }

        // Delete
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        // Return
        return Unit.Value;
    }
}
