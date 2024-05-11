﻿using System;
using System.IO;
using ValveKeyValue.Abstraction;
using ValveKeyValue.Deserialization;
using ValveKeyValue.Deserialization.KeyValues1;

namespace ValveKeyValue
{
    /// <summary>
    /// Helper class to easily deserialize KeyValue objects.
    /// </summary>
    public class KVSerializer
    {
        KVSerializer(KVSerializationFormat format)
        {
            this.format = format;
        }

        readonly KVSerializationFormat format;

        /// <summary>
        /// Creates a new <see cref="KVSerializer"/> for the given format.
        /// </summary>
        /// <param name="format">The <see cref="KVSerializationFormat"/> to use when (de)serializing. </param>
        /// <returns>A new <see cref="KVSerializer"/> that (de)serializes with the given format.</returns>
        public static KVSerializer Create(KVSerializationFormat format)
        {
            return new KVSerializer(format);
        }

        /// <summary>
        /// Deserializes a KeyValue object from a stream.
        /// </summary>
        /// <param name="stream">The stream to deserialize from.</param>
        /// <param name="options">Options to use that can influence the deserialization process.</param>
        /// <returns>A <see cref="KVObject"/> representing the KeyValues structure encoded in the stream.</returns>
        public KVObject Deserialize(Stream stream, KVSerializerOptions options = null)
        {
            Require.NotNull(stream, "stream");
            var builder = new KVObjectBuilder();

            using (var reader = MakeReader(stream, builder, options ?? KVSerializerOptions.DefaultOptions))
            {
                reader.ReadObject();
            }

            return builder.GetObject();
        }
        
        IVisitingReader MakeReader(Stream stream, IParsingVisitationListener listener, KVSerializerOptions options)
        {
            Require.NotNull(stream, "stream");
            Require.NotNull(listener, "listener");
            Require.NotNull(options, "options");

            switch(format)
            {
                case KVSerializationFormat.KeyValues1Text: return new KV1TextReader(new StreamReader(stream), listener, options);
                case KVSerializationFormat.KeyValues1Binary: return new KV1BinaryReader(stream, listener);
                default: throw new ArgumentOutOfRangeException("format", format, "Invalid serialization format.");
            };
        }
    }
}
