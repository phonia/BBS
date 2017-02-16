using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Simple.Models;

namespace Simple.Repository
{
    public class PostRepository:EFRepository<Post,Int32>,IPostRepository
    {
    }
}