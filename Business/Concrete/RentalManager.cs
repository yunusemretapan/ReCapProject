using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if ((_rentalDal.Get(p => p.CarId == rental.CarId)) == null)//araba kiralanmamşısa
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalSuccessAdded);
            }
            else //araba daha önce kiralamışsa
            {
                foreach (var rentalList in _rentalDal.GetAll())
                {
                    if (rentalList.CarId == rental.CarId)//arabanın kiralama listesini alıyoruz
                    {
                        if (rentalList.ReturnDate != null)//araba daha önce kiralanmış ama geri verilmiş olan
                        {
                            _rentalDal.Add(rental);
                            return new SuccessResult(Messages.RentalSuccessAdded);
                        }
                    }
                }
                //kiralanmış ama geri verilmemiş                
                return new ErrorResult(Messages.RentalErrorAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
