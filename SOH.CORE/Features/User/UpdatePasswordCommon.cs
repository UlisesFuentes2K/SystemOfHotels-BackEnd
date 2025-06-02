using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class UpdatePasswordCommon : IRequest<bool>
    {
        public string? Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
    internal class UpdatePasswordCommonHandler : IRequestHandler<UpdatePasswordCommon, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePasswordCommonHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdatePasswordCommon request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<SR_Users>(request);
            if (request.Id == null)
            {
                var data = await _unitOfWork.IUser.GetUserByEmailAsync(map.Email);
                map.Id = data.Id;
                return await _unitOfWork.IUser.UpdatePasswordAsync(map);
            }
            return await _unitOfWork.IUser.UpdatePasswordAsync(map);
        }
    }
}
