using ITI.Context;
using ITI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Repository
{
    public class TopicRepository
    {
        private readonly ITIDbContext _context;

        // Constructor
        public TopicRepository(ITIDbContext context)
        {
            _context = context;
        }

        // Create (Add) Operation
        public void AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
        }

        // Read (Retrieve) Operations
        public IEnumerable<Topic> GetAllTopics()
        {
            return _context.Topics.ToList();
        }

        public Topic GetTopicById(int id)
        {
            return _context.Topics.FirstOrDefault(t => t.ID == id);
        }

        // Update Operation
        public void UpdateTopic(Topic topic)
        {
            _context.Topics.Update(topic);
            _context.SaveChanges();
        }

        // Delete Operation
        public void DeleteTopic(int id)
        {
            var topic = _context.Topics.Find(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                _context.SaveChanges();
            }
        }
    }
}
