﻿using LXP.Common.Entities;
using LXP.Data.IRepository;
using Microsoft.EntityFrameworkCore;


namespace LXP.Data.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly LXPDbContext _lXPDbContext;
        public MaterialRepository(LXPDbContext lXPDbContext)
        {
            _lXPDbContext = lXPDbContext;
        }
        public async Task AddMaterial(Material material)
        {
            await _lXPDbContext.Materials.AddAsync(material);
            await _lXPDbContext.SaveChangesAsync();

        }

        public async Task<bool> AnyMaterialByMaterialNameAndTopic(string materialName, Topic topic)
        {
            return await _lXPDbContext.Materials.AnyAsync(material => material.Name == materialName && material.Topic == topic);
        }
        public async Task<Material> GetMaterialByMaterialNameAndTopic(string materialName, Topic topic)
        {
            return await _lXPDbContext.Materials.FirstOrDefaultAsync(material => material.Name == materialName && material.Topic == topic);
        }
        public List<Material> GetAllMaterialDetailsByTopicAndType(Topic topic, MaterialType materialType)
        {
            return _lXPDbContext.Materials.Where(material => material.IsActive == true && material.Topic == topic && material.MaterialType == materialType).Include(material => material.Topic).Include(material => material.MaterialType).OrderBy(material => material.CreatedAt).ToList();

        }

        public async Task<Material> GetMaterialById(Guid materialId)
        {
            return await _lXPDbContext.Materials.FirstOrDefaultAsync(material => material.MaterialId == materialId);
        }
      public async Task<List<Material>> GetMaterialsByTopic(Guid topic)
        {
            return await _lXPDbContext.Materials.Where(material=>material.TopicId == topic).ToListAsync();
        }
        public async Task<Material> GetMaterialByMaterialId(Guid materialId)
        {
            return await _lXPDbContext.Materials.Include(material => material.MaterialType).Include(material => material.Topic).FirstAsync(material => material.MaterialId == materialId);
        }
        //end 
        public async Task<int> UpdateMaterial(Material material)
        {
            _lXPDbContext.Materials.Update(material);
            return await _lXPDbContext.SaveChangesAsync();
        }







    }
}
