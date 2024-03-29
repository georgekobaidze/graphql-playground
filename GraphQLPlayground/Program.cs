﻿using GraphQL.Server.Ui.Voyager;
using GraphQLPlayground.Data;
using GraphQLPlayground.GraphQL;
using GraphQLPlayground.GraphQL.Commands;
using GraphQLPlayground.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("GraphQLPlaygroundConnectionString");

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddGraphQLServer()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseWebSockets();

app.UseRouting();

app.UseEndpoints(enpoints =>
{
    enpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

app.Run();
