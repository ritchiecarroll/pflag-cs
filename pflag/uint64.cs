namespace go.github.com.spf13;

using strconv = strconv_package;

partial class pflag_package {

partial struct uint64Value /*num:uint64*/;

internal static ж<uint64Value> newUint64Value(uint64 val, ж<uint64> Ꮡp) {
    ref var p = ref Ꮡp.DerefOrNull();

    p = val;
    return Ꮡp.Reinterpret<uint64, uint64Value>();
}

internal static error Set(this ref uint64Value i, @string s) {
    var (v, err) = strconv.ParseUint(s, 0, 64);
    i = ((uint64Value)v);
    return err;
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string uint64ˢ = "uint64"u8;

internal static @string Type(this ref uint64Value i) {
    return uint64ˢ;
}

internal static @string String(this ref uint64Value i) {
    return strconv.FormatUint((uint64)(i), 10);
}

internal static (any, error) uint64Conv(@string sval) {
    var (v, err) = strconv.ParseUint(sval, 0, 64);
    if (err != default!) {
        return ((nint)(0), err);
    }
    return ((uint64)v, default!);
}

public static (uint64, error) GetUint64(this ж<FlagSet> Ꮡf, @string name) {
    var (val, err) = Ꮡf.getFlagType(name, uint64ˢ, uint64Conv);
    if (err != default!) {
        return (0, err);
    }
    return (val._<uint64>(), default!);
}

public static void Uint64Var(this ж<FlagSet> Ꮡf, ж<uint64> Ꮡp, @string name, uint64 value, @string usage) {
    Ꮡf.VarP(new uint64ValueжValue(newUint64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void Uint64VarP(this ж<FlagSet> Ꮡf, ж<uint64> Ꮡp, @string name, @string shorthand, uint64 value, @string usage) {
    Ꮡf.VarP(new uint64ValueжValue(newUint64Value(value, Ꮡp)), name, shorthand, usage);
}

public static void Uint64Var(ж<uint64> Ꮡp, @string name, uint64 value, @string usage) {
    CommandLine.VarP(new uint64ValueжValue(newUint64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void Uint64VarP(ж<uint64> Ꮡp, @string name, @string shorthand, uint64 value, @string usage) {
    CommandLine.VarP(new uint64ValueжValue(newUint64Value(value, Ꮡp)), name, shorthand, usage);
}

public static ж<uint64> Uint64(this ж<FlagSet> Ꮡf, @string name, uint64 value, @string usage) {
    var p = @new<uint64>();
    Ꮡf.Uint64VarP(p, name, ""u8, value, usage);
    return p;
}

public static ж<uint64> Uint64P(this ж<FlagSet> Ꮡf, @string name, @string shorthand, uint64 value, @string usage) {
    var p = @new<uint64>();
    Ꮡf.Uint64VarP(p, name, shorthand, value, usage);
    return p;
}

public static ж<uint64> Uint64(@string name, uint64 value, @string usage) {
    return CommandLine.Uint64P(name, ""u8, value, usage);
}

public static ж<uint64> Uint64P(@string name, @string shorthand, uint64 value, @string usage) {
    return CommandLine.Uint64P(name, shorthand, value, usage);
}

} // end pflag_package
