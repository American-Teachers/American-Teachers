import path from "path";
import HtmlWebpackPlugin from "html-webpack-plugin";
import Dotenv from "dotenv-webpack";


module.exports = {
    entry: path.resolve(__dirname, "src/index.js"),
    output: {
      path: path.resolve(__dirname, "build"),
      publicPath: "/",
      filename: "[name].bundle.js",
    },
    optimization: {
      splitChunks: {
        cacheGroups: {
          node_vendors: {
            test: /[\\/]node_modules[\\/]/,
            chunks: "all",
            priority: 1,
          },
        },
        chunks: "all",
      },
    },
    mode: process.env.NODE_ENV || "development",
    resolve: {
      modules: [path.resolve(__dirname, "src"), "node_modules"],
      extensions: [".js", ".jsx", ".json"],
    },
    devServer: {
      contentBase: path.join(__dirname, "src"),
      historyApiFallback: true,
      compress: true,
      port: 3000,
    },
    module: {
      rules: [
        {
          // this is so that we can compile any React,
          // ES6 and above into normal ES5 syntax
          test: /\.(js|jsx)$/,
          // we do not want anything from node_modules to be compiled
          exclude: /node_modules/,
          use: ["babel-loader"]
        },
        {
          test: /\.(css|scss)$/,
          use: [
            "style-loader", // creates style nodes from JS strings
            "css-loader", // translates CSS into CommonJS
            "sass-loader", // compiles Sass to CSS, using Node Sass by default
          ],
        },
        {
          test: /\.(jpg|jpeg|png|gif|mp3|ico)$/,
          loader: ["file-loader"],
        },
        {
          test: /\.(ttf|eot|woff|svg)$/,
          loader: ["url-loader"],
        },
      ],
    },
    plugins: [
      new HtmlWebpackPlugin({
        template: path.join(__dirname, "public", "index.html"),
        favicon: "./public/favicon.ico"
      }),
      new Dotenv(),
    ],
  };
