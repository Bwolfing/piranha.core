/*
 * Copyright (c) 2016 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using Piranha.Repositories;

namespace Piranha
{
    /// <summary>
    /// Basic implementation of the application api.
    /// </summary>
    public class CachedApi : IApi 
    {
        #region Members
        /// <summary>
        /// The private data service.
        /// </summary>
        private readonly IDataService service;
        
        /// <summary>
        /// The private cache.
        /// </summary>
        private readonly IDistributedCache cache;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the archive repository.
        /// </summary>
        public IArchiveRepository Archives { 
            get { return service.Archives; } 
        }

        /// <summary>
        /// Gets the block type repository.
        /// </summary>
        public IBlockTypeRepository BlockTypes { 
            get { return service.BlockTypes; }
        }

        /// <summary>
        /// Gets the category repository.
        /// </summary>
        public ICategoryRepository Categories { 
            get { return service.Categories; }
        }

        /// <summary>
        /// Gets the page repository.
        /// </summary>
        public IPageRepository Pages { get; private set; }

        /// <summary>
        /// Gets the page type repository.
        /// </summary>
        public IPageTypeRepository PageTypes { 
            get { return service.PageTypes; }
        }

        /// <summary>
        /// Gets the post repository.
        /// </summary>
        public IPostRepository Posts { 
            get { return service.Posts; }
        }

        /// <summary>
        /// Gets the sitemap repository.
        /// </summary>
        public ISitemapRepository Sitemap { 
            get { return service.Sitemap; }
        }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="service">The configured data service</param>
        /// <param name="cache">The configured cache</param>
        public CachedApi(IDataService service, IDistributedCache cache, ILoggerFactory logFactory) {
            this.service = service;
            this.cache = cache;

            Pages = new CachedPageRepository(service.Pages, cache, logFactory);
        }

        /// <summary>
        /// Disposes the Api.
        /// </summary>
        public void Dispose() {
            service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}