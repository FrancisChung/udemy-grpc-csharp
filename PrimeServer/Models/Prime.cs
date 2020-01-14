// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: prime.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PrimeAPI {

  /// <summary>Holder for reflection information generated from prime.proto</summary>
  public static partial class PrimeReflection {

    #region Descriptor
    /// <summary>File descriptor for prime.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PrimeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtwcmltZS5wcm90bxIIUHJpbWVBUEkiHgoMUHJpbWVSZXF1ZXN0Eg4KBk51",
            "bWJlchgBIAEoBSImCg1QcmltZVJlc3BvbnNlEhUKDURlY29tcG9zaXRpb24Y",
            "ASABKAUyUAoMUHJpbWVTZXJ2aWNlEkAKCURlY29tcG9zZRIWLlByaW1lQVBJ",
            "LlByaW1lUmVxdWVzdBoXLlByaW1lQVBJLlByaW1lUmVzcG9uc2UiADABYgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PrimeAPI.PrimeRequest), global::PrimeAPI.PrimeRequest.Parser, new[]{ "Number" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PrimeAPI.PrimeResponse), global::PrimeAPI.PrimeResponse.Parser, new[]{ "Decomposition" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PrimeRequest : pb::IMessage<PrimeRequest> {
    private static readonly pb::MessageParser<PrimeRequest> _parser = new pb::MessageParser<PrimeRequest>(() => new PrimeRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PrimeRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PrimeAPI.PrimeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeRequest(PrimeRequest other) : this() {
      number_ = other.number_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeRequest Clone() {
      return new PrimeRequest(this);
    }

    /// <summary>Field number for the "Number" field.</summary>
    public const int NumberFieldNumber = 1;
    private int number_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Number {
      get { return number_; }
      set {
        number_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PrimeRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PrimeRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Number != other.Number) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Number != 0) hash ^= Number.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Number != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Number);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Number != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Number);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PrimeRequest other) {
      if (other == null) {
        return;
      }
      if (other.Number != 0) {
        Number = other.Number;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Number = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class PrimeResponse : pb::IMessage<PrimeResponse> {
    private static readonly pb::MessageParser<PrimeResponse> _parser = new pb::MessageParser<PrimeResponse>(() => new PrimeResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PrimeResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PrimeAPI.PrimeReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeResponse(PrimeResponse other) : this() {
      decomposition_ = other.decomposition_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PrimeResponse Clone() {
      return new PrimeResponse(this);
    }

    /// <summary>Field number for the "Decomposition" field.</summary>
    public const int DecompositionFieldNumber = 1;
    private int decomposition_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Decomposition {
      get { return decomposition_; }
      set {
        decomposition_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PrimeResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PrimeResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Decomposition != other.Decomposition) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Decomposition != 0) hash ^= Decomposition.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Decomposition != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Decomposition);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Decomposition != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Decomposition);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PrimeResponse other) {
      if (other == null) {
        return;
      }
      if (other.Decomposition != 0) {
        Decomposition = other.Decomposition;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Decomposition = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code