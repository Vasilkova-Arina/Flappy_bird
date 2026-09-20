package com.example.pr01.usersmodel

import com.example.pr01.usersmodel.service.UserInterface
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitClient {
    val loggingInterceptor = HttpLoggingInterceptor().apply {
        level = HttpLoggingInterceptor.Level.BODY
    }
    val okHttpClient = okHttpClient.Builder
        .addInterceptor(loggingInterceptor)
        .build()
    private val retrofit = Retrofit.Builder()
        .baseUrl("https://dummyjson.com/")
        .client("OkHttpClient")
        .addConverterFactory(GsonConverterFactory.create())
        .build()
    val UserApi: UserInterface = retrofit.create(UserInterface::class.java)
}