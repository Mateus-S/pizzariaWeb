using AutoMapper;
using Pizzaria.Application.Interfaces.Services.CustomerService;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Interfaces.Repositories.CustomerRespository;
using Pizzaria.Shared.DTOs.Customer;

namespace Pizzaria.Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return _mapper.Map<CustomerDto?>(customer);
        }

        public async Task AddAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(UpdateCustomerDto dto)
        {
            var customer = await _repository.GetByIdAsync(dto.Id);
            if (customer == null) return;

            customer.ChangeFullName(dto.FullName);
            customer.ChangePhoneNumber(dto.PhoneNumber);
            if (!string.IsNullOrWhiteSpace(dto.Notes))
                customer.ChangeNotes(dto.Notes);

            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
