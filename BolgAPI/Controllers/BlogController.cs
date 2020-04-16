using BolgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BolgAPI.Controllers
{
    public class BlogController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public int Login(BlogModel blog)
        {
            try
            {
                string sql = $"select count(1) from UserInfo where UserName='{blog.UserName}' and Pwd='{blog.Pwd}'";
                return Convert.ToInt32(DBHelper.ExecuteScalar(sql));
            }
            catch (Exception)
            {

                throw;
            }            
        }
        /// <summary>
        /// 显示所有留言
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<BlogModel> GetBlogs()
        {
            try
            {
                string sql = "select *from MessInfo m join UserInfo u on m.UserId=u.Id";
                return DBHelper.GetToList<BlogModel>(sql);
            }
            catch (Exception)
            {

                throw;
            }            
        }
        /// <summary>
        /// 根据内容和时间模糊查询
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpGet]
        public List<BlogModel> GetBlogs(BlogModel blog)
        {
            try
            {
                string sql = $"select *from MessInfo m join UserInfo u on m.UserId=u.Id where m.Content like '%'+{blog.Content}+'%' or m.Mtime ='{blog.Mtime}'";
                return DBHelper.GetToList<BlogModel>(sql);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        /// <summary>
        /// 根据状态查询
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpGet]
        public List<BlogModel> GetBlogState(BlogModel blog)
        {
            try
            {
                string sql = $"select *from MessInfo m join UserInfo u on m.Mstate='{blog.Mstate}'";
                return DBHelper.GetToList<BlogModel>(sql);
            }
            catch (Exception)
            {

                throw;
            }            
        }
        /// <summary>
        /// 修改留言状态
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public int UptMess(BlogModel blog)
        {
            try
            {
                blog.Mstate = 0;
                if(blog.Mstate==0)
                {
                    string sql = $"update MessInfo set blog.Mstate=1";
                    return DBHelper.ExecuteNonQuery(sql);
                }
                else
                {
                    string sql = $"update MessInfo set blog.Mstate=0";
                    return DBHelper.ExecuteNonQuery(sql);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 添加回复留言
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public int ReplyBolgs(BlogModel blog)
        {
            try
            {
                blog.Mtime = DateTime.Now;
                string sql = $"insert into ReplyInfo values('{blog.RmId}','{blog.Rcontent}','{blog.Rtime}','{blog.UId}')";
                return DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
