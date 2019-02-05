using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PocInkDataLayer;
using PocInkDataLayer.Models;

namespace PocInkDAL.Services
{
    public class InkDrawingRepository : IInkDrawingRepository
    {
        private readonly PocInkDBContext _context;

        public InkDrawingRepository(PocInkDBContext context)
        {
            _context = context;
        }

        public IEnumerable<InkDrawing> GetInkDrawings()
        {
            return _context.InkDrawings.ToList();
        }

        public InkDrawing GetInkDrawingById(int inkDrawingId)
        {
            return _context.InkDrawings.Find(inkDrawingId);
        }

        public void InsertInkDrawing(InkDrawing inkDrawing)
        {
            _context.InkDrawings.Add(inkDrawing);
        }

        public void DeleteInkDrawing(int inkDrawingID)
        {
            InkDrawing inkDrawing = _context.InkDrawings.Find(inkDrawingID);
            _context.InkDrawings.Remove(inkDrawing);
        }

        public void UpdateInkDrawing(InkDrawing inkDrawing)
        {
            _context.Entry(inkDrawing).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
