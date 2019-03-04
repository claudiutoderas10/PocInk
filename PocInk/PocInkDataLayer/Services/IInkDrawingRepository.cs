using System;
using System.Collections.Generic;
using PocInkDataLayer.Models;

namespace PocInkDAL.Services
{
    public interface IInkDrawingRepository : IDisposable
    {
        IEnumerable<InkDrawing> GetInkDrawings();
        InkDrawing GetInkDrawingById(int inkDrawingId);
        void InsertInkDrawing(InkDrawing inkDrawing);
        void DeleteInkDrawing(int inkDrawingID);
        void UpdateInkDrawing(InkDrawing inkDrawing);
        void Save();
    }
}
