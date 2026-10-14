namespace go.github.com.spf13;

using strconv = strconv_package;

partial class pflag_package {

partial struct int64Value /*num:int64*/;

internal static ж<int64Value> newInt64Value(int64 val, ж<int64> Ꮡp) {
    ref var p = ref Ꮡp.DerefOrNull();

    p = val;
    return Ꮡp.Reinterpret<int64, int64Value>();
}

internal static error Set(this ref int64Value i, @string s) {
    var (v, err) = strconv.ParseInt(s, 0, 64);
    i = ((int64Value)v);
    return err;
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string int64ˢ = "int64"u8;

internal static @string Type(this ref int64Value i) {
    return int64ˢ;
}

internal static @string String(this ref int64Value i) {
    return strconv.FormatInt((int64)(i), 10);
}

internal static (any, error) int64Conv(@string sval) {
    var (ᴛ1, ᴛ2) = strconv.ParseInt(sval, 0, 64);
    return (ᴛ1, ᴛ2);
}

public static (int64, error) GetInt64(this ж<FlagSet> Ꮡf, @string name) {
    var (val, err) = Ꮡf.getFlagType(name, int64ˢ, int64Conv);
    if (err != default!) {
        return (0, err);
    }
    return (val._<int64>(), default!);
}

public static void Int64Var(this ж<FlagSet> Ꮡf, ж<int64> Ꮡp, @string name, int64 value, @string usage) {
    Ꮡf.VarP(new int64ValueжValue(newInt64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void Int64VarP(this ж<FlagSet> Ꮡf, ж<int64> Ꮡp, @string name, @string shorthand, int64 value, @string usage) {
    Ꮡf.VarP(new int64ValueжValue(newInt64Value(value, Ꮡp)), name, shorthand, usage);
}

public static void Int64Var(ж<int64> Ꮡp, @string name, int64 value, @string usage) {
    CommandLine.VarP(new int64ValueжValue(newInt64Value(value, Ꮡp)), name, ""u8, usage);
}

public static void Int64VarP(ж<int64> Ꮡp, @string name, @string shorthand, int64 value, @string usage) {
    CommandLine.VarP(new int64ValueжValue(newInt64Value(value, Ꮡp)), name, shorthand, usage);
}

public static ж<int64> Int64(this ж<FlagSet> Ꮡf, @string name, int64 value, @string usage) {
    var p = @new<int64>();
    Ꮡf.Int64VarP(p, name, ""u8, value, usage);
    return p;
}

public static ж<int64> Int64P(this ж<FlagSet> Ꮡf, @string name, @string shorthand, int64 value, @string usage) {
    var p = @new<int64>();
    Ꮡf.Int64VarP(p, name, shorthand, value, usage);
    return p;
}

public static ж<int64> Int64(@string name, int64 value, @string usage) {
    return CommandLine.Int64P(name, ""u8, value, usage);
}

public static ж<int64> Int64P(@string name, @string shorthand, int64 value, @string usage) {
    return CommandLine.Int64P(name, shorthand, value, usage);
}

} // end pflag_package
