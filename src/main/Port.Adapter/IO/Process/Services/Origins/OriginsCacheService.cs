﻿/*
    This file is part of the d# project.
    Copyright (c) 2016-2018 ei8
    Authors: ei8
     This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    EI8. EI8 DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS
     This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
    https://github.com/ei8/cortex-diary/blob/master/LICENSE
     The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
     You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the d# software without
    disclosing the source code of your own applications.
     For more information, please contact ei8 at this address: 
     support@ei8.works
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ei8.Cortex.Diary.Domain.Model.Origin;

namespace ei8.Cortex.Diary.Port.Adapter.IO.Process.Services.Origins
{
    public class OriginsCacheService : IOriginsCacheService
    {
        private readonly Dictionary<string, Avatar> avatars;
        private readonly Dictionary<string, Server> servers;

        public OriginsCacheService()
        {
            this.avatars = new Dictionary<string, Avatar>();
            this.servers = new Dictionary<string, Server>();
        }

        public void Add(Avatar value)
        {
            this.avatars.Add(value.Id, value);
        }

        public void Add(Server value)
        {
            this.servers.Add(value.Id, value);
        }

        public bool ContainsAvatar(string avatarUrl)
        {
            IEnumerable<AvatarUrl> uas = this.GetAvatarUrls();

            return uas.Any(ua => ua.Url == avatarUrl);
        }

        private IEnumerable<AvatarUrl> GetAvatarUrls()
        {
            return from se in this.servers.Values
                   from av in this.avatars.Values
                   where se.Id == av.ServerId
                   select new AvatarUrl(av, $"{se.Url}/{av.Name}");
        }

        public bool ContainsServer(string serverUrl)
        {
            return this.servers.Values.Any(s => s.Url == serverUrl);
        }

        public Avatar GetAvatarByUrl(string avatarUrl)
        {
            return this.GetAvatarUrls().First(au => au.Url == avatarUrl).Avatar;
        }

        public Server GetServerByUrl(string serverUrl)
        {
            return this.servers.Values.First(s => s.Url == serverUrl);
        }
    }
}
