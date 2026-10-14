namespace go.github.com.spf13;

using strconv = strconv_package;

partial class pflag_package {

partial interface boolFlag :
    Value
{
    bool IsBoolFlag();
}

partial struct boolValue /*bool*/;

internal static ж<boolValue> newBoolValue(bool val, ж<bool> Ꮡp) {
    ref var p = ref Ꮡp.DerefOrNull();

    p = val;
    return Ꮡp.Reinterpret<bool, boolValue>();
}

internal static error Set(this ref boolValue b, @string s) {
    var (v, err) = strconv.ParseBool(s);
    b = ((boolValue)v);
    return err;
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string boolˢ = "bool"u8;

internal static @string Type(this ref boolValue b) {
    return boolˢ;
}

internal static @string String(this ref boolValue b) {
    return strconv.FormatBool((bool)(b));
}

internal static bool IsBoolFlag(this ref boolValue b) {
    return true;
}

internal static (any, error) boolConv(@string sval) {
    var (ᴛ1, ᴛ2) = strconv.ParseBool(sval);
    return (ᴛ1, ᴛ2);
}

public static (bool, error) GetBool(this ж<FlagSet> Ꮡf, @string name) {
    var (val, err) = Ꮡf.getFlagType(name, boolˢ, boolConv);
    if (err != default!) {
        return (false, err);
    }
    return (val._<bool>(), default!);
}

public static void BoolVar(this ж<FlagSet> Ꮡf, ж<bool> Ꮡp, @string name, bool value, @string usage) {
    Ꮡf.BoolVarP(Ꮡp, name, ""u8, value, usage);
}

// Hoisted @string literals (single allocation; Go keeps these in RODATA)
internal static readonly @string trueˢ = "true"u8;

public static void BoolVarP(this ж<FlagSet> Ꮡf, ж<bool> Ꮡp, @string name, @string shorthand, bool value, @string usage) {
    var flag = Ꮡf.VarPF(new boolValueжValue(newBoolValue(value, Ꮡp)), name, shorthand, usage);
    flag.Value.NoOptDefVal = trueˢ;
}

public static void BoolVar(ж<bool> Ꮡp, @string name, bool value, @string usage) {
    BoolVarP(Ꮡp, name, ""u8, value, usage);
}

public static void BoolVarP(ж<bool> Ꮡp, @string name, @string shorthand, bool value, @string usage) {
    var flag = CommandLine.VarPF(new boolValueжValue(newBoolValue(value, Ꮡp)), name, shorthand, usage);
    flag.Value.NoOptDefVal = trueˢ;
}

public static ж<bool> Bool(this ж<FlagSet> Ꮡf, @string name, bool value, @string usage) {
    return Ꮡf.BoolP(name, ""u8, value, usage);
}

public static ж<bool> BoolP(this ж<FlagSet> Ꮡf, @string name, @string shorthand, bool value, @string usage) {
    var p = @new<bool>();
    Ꮡf.BoolVarP(p, name, shorthand, value, usage);
    return p;
}

public static ж<bool> Bool(@string name, bool value, @string usage) {
    return BoolP(name, ""u8, value, usage);
}

public static ж<bool> BoolP(@string name, @string shorthand, bool value, @string usage) {
    var b = CommandLine.BoolP(name, shorthand, value, usage);
    return b;
}

} // end pflag_package
