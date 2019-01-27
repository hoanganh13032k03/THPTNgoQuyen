using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class NewsDao
    {
        DBContext db = null;

        public NewsDao()
        {

            db = new DBContext();
        }
        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<News> ListAllPaging(int page, int pageSize)
        {
            List<News> model = ToList().ToPagedList(page, pageSize).ToList();
            return model;
        }
        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<News> ListAcitvePaging(int page, int pageSize)
        {
            List<News> model = ToListActive().ToPagedList(page,pageSize).ToList();
            return model;
        }
        public List<News> ToList()
        {
            return db.News.OrderByDescending(x=>x.ModifiedDate).ToList<News>();
        }
        public List<News> ToListActive()
        {
            return db.News.Where(x=>x.Status==1).OrderByDescending(x => x.PublishedDate).ToList<News>();
        }

        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<News> ListtiveByCateIDPaging(long catID,int page=1, int pageSize=1)
        {
            List<News> model = ToActiveByCateID(catID).ToPagedList(page, pageSize).ToList();
            return model;
        }
        public List<News> ToActiveByCateID(long catID)


        {
            string scatID = catID.ToString();
            List<News> lstActive = db.News.Where(x => x.Status == 1).OrderByDescending(x => x.PublishedDate).ToList<News>();
            List<News> lstReust =  new List<News>();
            foreach(var n in lstActive)
            {
                if (HepperString.GetListByKey(n.CategoryID, ";").Contains(scatID))
                {
                    lstReust.Add(n);
                }
            }
            return lstReust;
        }
        public int ListAllByTagCount(string tag)
        {
            var model = (from a in db.News
                         join b in db.NewsTags
                         on a.NewsID equals b.NewsID
                         where b.TagID == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTite,
                             Image = a.Image,
                             Description = a.Description,
                             PublishedDate = a.PublishedDate,
                             MetaDescription = a.MetaDescription,
                             MetakeyWords = a.MetakeyWords,
                             Title = a.Title,
                             ShowShare = a.ShowShare,
                             ShowConment = a.ShowConment,
                             ID = a.NewsID

                         }).AsEnumerable().Count();
            return model;
        }
        public List<News> ListAllByTag(string tag, int page, int pageSize)
        {
            var model = (from a in db.News
                         join b in db.NewsTags
                         on a.NewsID equals b.NewsID
                         where b.TagID == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTite,
                             Image = a.Image,
                             Description = a.Description,
                             PublishedDate = a.PublishedDate,
                             MetaDescription = a.MetaDescription,
                             MetakeyWords = a.MetakeyWords,
                             Title = a.Title,
                             ShowShare = a.ShowShare,
                             ShowConment = a.ShowConment,
                             Source = a.Source,
                             ID = a.NewsID

                         }).AsEnumerable().Select(x => new News()
                         {
                             Name = x.Name,
                             MetaTite = x.MetaTitle,
                             Image = x.Image,
                             Description = x.Description,
                             PublishedDate = x.PublishedDate,
                             MetakeyWords = x.MetakeyWords,
                             MetaDescription = x.MetaDescription,
                             ShowShare = x.ShowShare,
                             ShowConment = x.ShowConment,
                             Source = x.Source,
                             Title = x.Title,
                             NewsID = x.ID
                         });
            return model.OrderByDescending(x => x.PublishedDate).ToPagedList(page, pageSize).ToList();
        }

        public long Insert(News mode)
        {
            
                if (string.IsNullOrEmpty(mode.MetaTite))
                {
                    
                    mode.MetaTite = HepperString.ToUnsignString(mode.Name);
                }
                if (string.IsNullOrEmpty(mode.Title))
                {

                    mode.Title = mode.Name;
                }
                mode.ViewCount = 0;
                mode.PublishedDate = DateTime.Now;
                db.News.Add(mode);
                db.SaveChanges();
                //Xử lý tag
                if (!string.IsNullOrEmpty(mode.Tags))
                {
                    string[] tags = mode.Tags.Split(',');
                    foreach (var tag in tags)
                    {
                        var tagId = HepperString.ToUnsignString(tag);
                        var existedTag = this.CheckTag(tagId);

                        //insert to to tag table
                        if (!existedTag)
                        {
                            this.InsertTag(tagId, tag);
                        }

                        //insert to content tag
                        this.InsertNewsTag(mode.NewsID, tagId);

                    }
                }
                return mode.NewsID;

          


        }
        public void RemoveAllContentTag(long newsId)
        {
            db.NewsTags.RemoveRange(db.NewsTags.Where(x => x.NewsID == newsId));
            db.SaveChanges();
        }
        public void InsertTag(string id, string name)
        {
            var tag = new Tag();
            tag.TagID = id;
            tag.Name = name;
            db.Tags.Add(tag);
            db.SaveChanges();
        }

        public void InsertNewsTag(long newsId, string tagId)
        {
            var newsTag = new NewsTag();
            newsTag.NewsID = newsId;
            newsTag.TagID = tagId;
            db.NewsTags.Add(newsTag);
            db.SaveChanges();
        }
        public bool CheckTag(string id)
        {
            return db.Tags.Count(x => x.TagID == id) > 0;
        }
        public List<Tag> ListTag(long newsID)
        {
            var model = (from a in db.Tags
                         join b in db.NewsTags
                         on a.TagID equals b.TagID
                         where b.NewsID == newsID
                         select new
                         {
                             ID = b.TagID,
                             Name = a.Name
                         }).AsEnumerable().Select(x => new Tag()
                         {
                             TagID = x.ID,
                             Name = x.Name
                         });
            return model.ToList();
        }
        public List<Tag> ListTag()
        {
            var model = (from a in db.Tags
                         select new
                         {
                             ID = a.TagID,
                             Name = a.Name
                         }).AsEnumerable().Select(x => new Tag()
                         {
                             TagID = x.ID,
                             Name = x.Name
                         });
            return model.ToList();
        }
        public bool Delete(long ID)
        {
            try
            {
                var bd = db.News.SingleOrDefault(a => a.NewsID == ID);
                db.News.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public News FindByID(long ID)
        {

            return db.News.Where(a => a.NewsID == ID).SingleOrDefault();
        }
        public long Publicer(News mode)
        {
            var bd = db.News.Find(mode.NewsID);
            bd.PublishedDate = mode.PublishedDate;
            bd.Status = mode.Status;
            return bd.NewsID;
        }

        public long Update(News mode)
        {
           
                var bd = db.News.Find(mode.NewsID);
            if (string.IsNullOrEmpty(mode.MetaTite))
            {

                bd.MetaTite = HepperString.ToUnsignString(mode.Name);
            }
            else
            {
                bd.MetaTite = mode.MetaTite;
            }
            if (string.IsNullOrEmpty(mode.Title))
            {

                bd.MetaTite = mode.Name;
            }
            else
            {
                bd.MetaTite = mode.MetaTite;
            }

            bd.NewsID = mode.NewsID;
            //bd.CreateBy = mode.CreateBy;
            //bd.CreateDate = mode.CreateDate;

            bd.CategoryID = mode.CategoryID;
            bd.ContentHtml = mode.ContentHtml;
            bd.Description = mode.Description;
            bd.Name = mode.Name;
             bd.PublishedDate = mode.PublishedDate;
            if (string.IsNullOrEmpty(mode.RelatedNewses))
            {

                bd.RelatedNewses = "";
            }
            else
            {
                bd.RelatedNewses = mode.RelatedNewses;
            }

            bd.ShowConment = mode.ShowConment;
            bd.ShowShare = mode.ShowShare;
            bd.UpTopHot = mode.UpTopHot;
            bd.UpTopNew = mode.UpTopNew;
            bd.ViewCount = mode.ViewCount;
            bd.Image = mode.Image;
            bd.LanguageID = mode.LanguageID;
            bd.MetaDescription = mode.MetaDescription;
            bd.MetakeyWords = mode.MetakeyWords;

            bd.ModifiedBy = mode.ModifiedBy;
            bd.ModifiedDate = mode.ModifiedDate;

            bd.Status = mode.Status;
           
            bd.Source = mode.Source;


            db.SaveChanges();
                //Xử lý tag
                if (!string.IsNullOrEmpty(mode.Tags))
                {
                    this.RemoveAllContentTag(mode.NewsID);
                    string[] tags = mode.Tags.Split(',');
                    foreach (var tag in tags)
                    {
                        var tagId = HepperString.ToUnsignString(tag);
                        var existedTag = this.CheckTag(tagId);

                        //insert to to tag table
                        if (!existedTag)
                        {
                            this.InsertTag(tagId, tag);
                        }

                        //insert to content tag
                        this.InsertNewsTag(mode.NewsID, tagId);

                    }
                }
            return mode.NewsID;


        }
        public Tag GetTag(string id)
        {
            return db.Tags.Find(id);
        }
    }
}
