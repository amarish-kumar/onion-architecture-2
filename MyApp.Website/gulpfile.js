/// <binding ProjectOpened='dev' />
var gulp = require('gulp');
var browserSync = require('browser-sync').create();
var pkg = require('./package.json');


var config = require('./gulp.config');
var localConfig = null; // loaded when needed

// Copy vendor files from /node_modules into /vendor
// NOTE: requires `npm install` before running!
gulp.task('copy', function () {
    gulp.src([
        'node_modules/bootstrap/dist/**/*',
        '!**/npm.js',
        '!**/bootstrap-theme.*',
        '!**/*.map'
    ])
        .pipe(gulp.dest('vendor/bootstrap'))

    gulp.src(['node_modules/jquery/dist/jquery.js', 'node_modules/jquery/dist/jquery.min.js'])
        .pipe(gulp.dest('vendor/jquery'))

    gulp.src(['node_modules/popper.js/dist/umd/popper.js', 'node_modules/popper.js/dist/umd/popper.min.js'])
        .pipe(gulp.dest('vendor/popper'))
})

// Default task
gulp.task('default', ['copy']);

// Configure the browserSync task
gulp.task('browserSync', function () {
    browserSync.init({
        proxy: 'localhost:85'
    })
})

// Dev task with browserSync
gulp.task('dev', ['browserSync'], function () {
    // Reloads the browser whenever HTML or CSS files change
    gulp.watch('Content/*.css', browserSync.reload);
    gulp.watch(config.paths.views, copyView);
    gulp.watch(config.paths.js, ['javascript']);
});

function copyView(file) {
    return gulp.src(file.path,
        { base: './' })
        .pipe(toWebInstance())
        .pipe(browserSync.reload({
            stream: true
        }));
}

gulp.task('javascript', function () {
    return compileJs()
        .pipe(toWebInstance())
        .pipe(browserSync.reload({
            stream: true
        }));
});


function compileJs() {
    console.log('Compiling JS...');

    return gulp.src([
        config.paths.js
    ], { base: './' });
}

// copy files to inepub app
function toWebInstance() {
    console.log('Copying to Web Instance..');
    if (!localConfig) {
        // this function is only run on dev machines so localConfig is safe to load
        localConfig = require('./localConfig');
    }
    return gulp.dest(localConfig.websiteRoot);
}