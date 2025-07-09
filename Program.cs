buider.Services.AddEndpointsApiExplorer(); 
buider.Services.AddSwaggerGen(); 
if(app.Environment.IsDevelopment())
{
app.UseSwagger(); 
app.UseSwaggerUI();

}
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("OperatorAccess", policy =>
        policy.RequireRole("Operator"));
});
