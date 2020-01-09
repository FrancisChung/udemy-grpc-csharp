// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: sumapi.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace SumAPI {
  public static partial class SumService
  {
    static readonly string __ServiceName = "SumAPI.SumService";

    static readonly grpc::Marshaller<global::SumAPI.SumRequest> __Marshaller_SumAPI_SumRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SumAPI.SumRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SumAPI.SumResponse> __Marshaller_SumAPI_SumResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SumAPI.SumResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::SumAPI.SumRequest, global::SumAPI.SumResponse> __Method_Sum = new grpc::Method<global::SumAPI.SumRequest, global::SumAPI.SumResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Sum",
        __Marshaller_SumAPI_SumRequest,
        __Marshaller_SumAPI_SumResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::SumAPI.SumapiReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SumService</summary>
    [grpc::BindServiceMethod(typeof(SumService), "BindService")]
    public abstract partial class SumServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::SumAPI.SumResponse> Sum(global::SumAPI.SumRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SumService</summary>
    public partial class SumServiceClient : grpc::ClientBase<SumServiceClient>
    {
      /// <summary>Creates a new client for SumService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SumServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SumService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SumServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SumServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SumServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::SumAPI.SumResponse Sum(global::SumAPI.SumRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Sum(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::SumAPI.SumResponse Sum(global::SumAPI.SumRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Sum, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::SumAPI.SumResponse> SumAsync(global::SumAPI.SumRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::SumAPI.SumResponse> SumAsync(global::SumAPI.SumRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Sum, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SumServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SumServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SumServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Sum, serviceImpl.Sum).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SumServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Sum, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SumAPI.SumRequest, global::SumAPI.SumResponse>(serviceImpl.Sum));
    }

  }
}
#endregion
