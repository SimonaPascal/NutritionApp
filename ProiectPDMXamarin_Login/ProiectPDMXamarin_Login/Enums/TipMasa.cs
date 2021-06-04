using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDMXamarin_Login.Enums
{
    public sealed class TipMasaEnum : SmartEnum<TipMasaEnum>
    {
        public static readonly TipMasaEnum MicDejun = new TipMasaEnum("Mic Dejun", 0);
        public static readonly TipMasaEnum Pranz = new TipMasaEnum(nameof(Pranz), 1);
        public static readonly TipMasaEnum Cina = new TipMasaEnum(nameof(Cina), 2);
        public static readonly TipMasaEnum Gustare = new TipMasaEnum(nameof(Gustare), 3);

        private TipMasaEnum(string name, int value) : base(name, value)
        {
        }
    }
}
