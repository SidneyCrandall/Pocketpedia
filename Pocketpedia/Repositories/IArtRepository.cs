﻿using Pocketpedia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pocketpedia.Repositories
{
    public interface IArtRepository
    {
        List<Art> GetAllArt();
        Task<List<Art>> ArtsFromApi();
        void Add(Art art);
    }
}