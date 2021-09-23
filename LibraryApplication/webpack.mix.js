let mix = require('laravel-mix'),
    publicPath = './wwwroot/assets/';

/*
 |--------------------------------------------------------------------------
 | Mix Asset Management
 |--------------------------------------------------------------------------
 |
 | Mix provides a clean, fluent API for defining some Webpack build steps
 | for your Laravel application. By default, we are compiling the Sass
 | file for your application, as well as bundling up your JS files.
 |
 */

mix
    .setPublicPath(publicPath)
    //.browserSync(browserSync)
    .sass('Assets/scss/app.scss', publicPath + 'css')
    .js('Assets/js/app.js', publicPath + 'js')
    .version();