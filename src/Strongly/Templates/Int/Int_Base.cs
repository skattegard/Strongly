﻿readonly partial struct TYPENAME : INTERFACES
{
    public int Value { get; }

    public TYPENAME(int value)
    {

        Validate(value);
        Value = value;
        
    }

    public TYPENAME()
    {
        int value = 0;
        Validate(value);
        Value = value;
    }
    static partial void Validate(int value); 
    
    public static readonly TYPENAME Empty = new TYPENAME(0);

    public bool Equals(TYPENAME other) => this.Value.Equals(other.Value);
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is TYPENAME other && Equals(other);
    }
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
    public static bool operator ==(TYPENAME a, TYPENAME b) => a.Equals(b);
    public static bool operator !=(TYPENAME a, TYPENAME b) => !(a == b);
    public static TYPENAME Parse(string value) => new TYPENAME(int.Parse(value));
    public static bool TryParse(string value, out TYPENAME result)
    {
        if (int.TryParse(value, out int parseResult))
        {
            result = new TYPENAME(parseResult);
            return true;
        }
        result = default;
        return false;
    }