using System;
using JetBrains.Annotations;

namespace Sample.Auth.Models
{
    public struct PasswordHash
    {
        public byte[] Hash { get; }
        public byte[] Salt { get; }

        public PasswordHash([NotNull] byte[] hash, [NotNull] byte[] salt)
        {
            Hash = hash ?? throw new ArgumentException("Invalid hash", nameof(hash));
            Salt = salt ?? throw new ArgumentException("Invalid salt", nameof(hash));
        }
    }
}