using BastideAyebApp.Data;
using BastideAyebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BastideAyebApp.Services;

public class DatabaseService
{
    private readonly AppDbContext _context;

    public DatabaseService(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task SaveCardAsync(CardModels card)
    {
        card.SavedAt = DateTime.Now;
        _context.SavedCards.Add(card);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CardModels>> GetSavedCardsAsync()
    {
        return await _context.SavedCards
            .OrderByDescending(c => c.SavedAt)
            .ToListAsync();
    }

    public async Task DeleteCardAsync(CardModels card)
    {
        _context.SavedCards.Remove(card);
        await _context.SaveChangesAsync();
    }
}