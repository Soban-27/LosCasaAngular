﻿using Microsoft.EntityFrameworkCore;
using LosCasaAngular.Models;
using LosCasaAngular.DAL;


namespace LosCasaAngular.DAL;

public class ListingRepository : InterListingRepository
{
    private readonly ListingDbContext _db;

    private readonly ILogger<ListingRepository> _logger;

    public ListingRepository(ListingDbContext db, ILogger<ListingRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<Listing>?> GetAll()
    {
        try
        {
            return await _db.Listings.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] listings ToListAsync() failed when GetAll(), error message: {e}", e.Message);
            return null;
        }

    }

    public async Task<Listing?> GetListingById(int id)
    {
        try
        {
            return await _db.Listings.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] listing FindAsync(id) failed when GetListingById for ListingId {ListingmId:0000}, error message: {e}", id, e.Message);
            return null;
        }

    }

    public async Task<bool> Create(Listing listing)
    {
        try
        {
            _db.Listings.Add(listing);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] listing creation failed for listing {@item}, error message: {e}", listing, e.Message);
            return false;
        }
    }

    public async Task<bool> Update(Listing listing)
    {
        try
        {
            _db.Listings.Update(listing);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] listing FindAsync(id) failed when updating the ListingId {ListingId:0000}, error message: {e}", listing, e.Message);
            return false;
        }

    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var listing = await _db.Listings.FindAsync(id);
            if (listing == null)
            {
                _logger.LogError("[ListingRepository] listing not found for the ListingId {ListingId:0000}", id);
                return false;
            }

            _db.Listings.Remove(listing);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] listing deletion failed for the ListingId {ListingId:0000}, error message: {e}", id, e.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Rent>?> GetAllRents()
    {
        try
        {
            return await _db.Rents.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] Rents ToListAsync() failed when GetAllRents(), error message: {e}", e.Message);
            return null;
        }
    }

    public async Task<Rent?> GetRentById(int id)
    {
        try
        {
            return await _db.Rents.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] Rent FindAsync(id) failed when GetRentById for RentId {RentId:0000}, error message: {e}", id, e.Message);
            return null;
        }
    }

    public async Task<bool> CreateRent(Rent rent)
    {
        try
        {
            _db.Rents.Add(rent);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] Rent creation failed for rent {@item}, error message: {e}", rent, e.Message);
            return false;
        }
    }

    public async Task<bool> UpdateRent(Rent rent)
    {
        try
        {
            _db.Rents.Update(rent);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] Rent FindAsync(id) failed when updating the RentId {RentId:0000}, error message: {e}", rent, e.Message);
            return false;
        }
    }

    public async Task<bool> DeleteRent(int id)
    {
        try
        {
            var rent = await _db.Rents.FindAsync(id);
            if (rent == null)
            {
                _logger.LogError("[ListingRepository] Rent not found for the RentId {RentId:0000}", id);
                return false;
            }

            _db.Rents.Remove(rent);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("[ListingRepository] Rent deletion failed for the RentId {RentId:0000}, error message: {e}", id, e.Message);
            return false;


        }

    }
}