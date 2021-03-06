﻿// OsmSharp - OpenStreetMap tools & library.
// Copyright (C) 2012 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace OsmSharp.Tools.Xml.Sources
{
    /// <summary>
    /// Represents an xml source for a file.
    /// </summary>
    public class XmlFileSource : IXmlSource
    {
        /// <summary>
        /// The reference to the file.
        /// </summary>
        private FileInfo _stream;

        /// <summary>
        /// Creates a new xml file source.
        /// </summary>
        /// <param name="filename"></param>
        public XmlFileSource(string filename)
        {
            _stream = new FileInfo(filename);
        }

        /// <summary>
        /// Creates a new xml file source.
        /// </summary>
        /// <param name="file"></param>
        public XmlFileSource(FileInfo file)
        {
            _stream = file;
        }

        #region IXmlSource Members

        /// <summary>
        /// Returns an xml reader.
        /// </summary>
        public XmlReader GetReader()
        {
            return XmlReader.Create(_stream.OpenRead());
        }

        /// <summary>
        /// Returns an xml writer.
        /// </summary>
        /// <returns></returns>
        public XmlWriter GetWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CheckCharacters = true;
            settings.CloseOutput = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.NewLineChars  = Environment.NewLine;
            settings.NewLineHandling = NewLineHandling.Entitize;
            settings.OmitXmlDeclaration = true;
            //if (!_stream.Exists)
            //{
                return XmlWriter.Create(_stream.OpenWrite(), settings);
            //}
            //return XmlWriter.Create(_stream.FullName, settings);
        }

        /// <summary>
        /// Returns true if this file source is readonly.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                //if (!_stream.CanWrite)
                //{
                //    return true;
                //}
                return false;
            }
        }

        /// <summary>
        /// Returns true if the file source has data.
        /// </summary>
        public bool HasData
        {
            get
            {
                return _stream.Length > 1;
            }
        }

        /// <summary>
        /// Closes this file source.
        /// </summary>
        public void Close()
        {
            _stream = null;
        }

        #endregion
    }
}
