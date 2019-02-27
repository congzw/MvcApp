//config for app_config_common
require.config({
    paths: {
        'jquery': '/Content/libs/jquery/jquery-2.1.0',
        'toastr': '/Content/libs/toastr/toastr',
        'bootstrap': '/Content/libs/bootstrap/bootstrap',
        'zqnb': '/Content/scripts/zqnb',
        'nbLog': '/Content/scripts/zqnb.log'
    },
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    }
});

//config for app_config_area1
require.config({
    paths: {
        'myClock': '/Content/scripts/demos/MyClock'
    },
    shim: {
        myclock: {
            exports: "myClock"
        }
    }
});

//config for app_config_area2
require.config({
    paths: {
        'echarts': '/Content/scripts/demos/echarts.min'
    },
    shim: {
        'echarts': {
            exports: ['echarts']
        }
    }
});

