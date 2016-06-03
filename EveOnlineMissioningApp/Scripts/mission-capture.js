jQuery(function ($) {

    //HTML Selections
    var $missionCaptureInfo = $('.mission-capture-info'),
        $missionCaptureControl = $('.mission-capture-controls'),
        $timerDisplay = $('.timer-display');

    //CONSTANTS
    var MISSION_CAPTURE_URI = '/api/missioncaptures/';

    //Objects
    var missionCaptures = [],
        startTime,
        endTime;

    //Object
    var MissionCapture = function(values)
    {
        var id,
            startTime,
            endTime,
            title;

        if (values.id)
        {
            this.id = id;
        }

        if (values.startTime)
        {
            this.startTime = values.startTime;
        }

        if(values.endTime)
        {
            this.endTime = values.endTime;
        }

        if(values.title)
        {
            this.title = values.title;
        }

        this.getId = function()
        {
            return this.id;
        }

        this.getStartTime = function()
        {
            return this.startTime;
        }

        this.getEndTime = function()
        {
            return this.endTime;
        }

        this.getTitle = function()
        {
            return this.title;
        }
    }

    //TODO GET ALL
    function getAllMissionCaptures()
    {
        var promise = $.ajax({
            url: MISSION_CAPTURE_URI,
            type: 'GET',
            dataType: 'json'
        });

        promise.done(function(results) {
            $.each(results, function() {
                missionCaptures.push(new MissionCapture(this));
            });

            return missionCaptures;
        });
    }

    //TODO DELETE

    //TODO UPDATE

    //TODO CREATE
    function postMissionCapture(newMissionCapture) {
        var promise = $.ajax({
            url: MISSION_CAPTURE_URI,
            type: 'POST',
            dataType: 'json',
            data: newMissionCapture
        });

        promise.done(function (data) {
            return data;
        });
    }

    //TODO GET
    function getMissionCapture(id)
    {
        var promise = $.ajax({
            url: MISSION_CAPTURE_URI + id,
            type: 'GET',
            dataType: 'json'
        });

        promise.done(function(data) {
            return new MissionCapture(data);
        });
    }

    //TODO construct mission capture objects

    //TODO set prop values

    //TODO pull prop values

    //Timer Display Object
    var timerDisplay = function($target)
    {
        //Html to use
        var $hour = $target.find('.hour-display'),
            $minute = $target.find('.minute-display'),
            $second = $target.find('.second-display');

        //Values being used
        var startTime,
            endTime,
            secondCount = 0,
            interval,
            sec,
            min,
            hour,
            inited = false;

        //Clears values no longer needed
        clearValues = function () {
            startTime = null;
            endTime = null;
            secondCount = 0;
            sec = 0;
            min = 0;
            hour = 0;
        }

        //Resets the timer display
        resetDisplay = function () {
            $hour.text('00');
            $minute.text('00');
            $second.text('00');
        }

        //Adds zero prefix if needed
        prefixZero = function (number) {
            var numStr = "";

            if (number - 10 < 0) {
                numStr = "0" + number;
            }
            else {
                numStr += number;
            }

            return numStr;
        }

        //Update Timer Display
        updateTimerDisplay = function () {
            secondCount++;

            //Increment Second, which we always do
            sec = parseInt($second.text());
            sec++;

            $second.text(prefixZero(sec));

            //Increment Minute
            if ((secondCount % 60) == 0)
            {
                $second.text('00');

                min = parseInt($minute.text());
                min++;

                $minute.text(prefixZero(min));
            }

            //Increment Hour
            if ((secondCount % 3600) == 0)
            {
                $minute.text('00');

                hour = parseInt($hour.text());
                hour++;

                $hour.text(prefixZero(hour));
                secondCount = 0;
            }
        }

        //Stops timer and resets info
        this.endTimer = function() {
            endTime = new Date();
            clearInterval(interval);
            $missionCaptureInfo.find('.end-time input').val(endTime);
            clearValues();
        }

        //Starts new timer, resets display if needed
        this.startTimer = function () {
            if (inited)
            {
                resetDisplay();
            }

            inited = true;
            startTime = new Date();

            $missionCaptureInfo.find('.start-time input').val(startTime);
            interval = setInterval(function () {
                updateTimerDisplay();
            }, 1000);
        }
    }

    //Setup control listeners
    function initControlListeners()
    {
        $missionCaptureControl.find('.btn-new').on('click', function () {
            var newMissionCapture = {};

            $missionCaptureInfo.find('input').each(function () {
                var $this = $(this),
                    name = $this.attr('name'),
                    val = $this.val();

                newMissionCapture[name] = val;
            });

            console.log(postMissionCapture(newMissionCapture));
        });
    }

    //Setup timer and necissary listeners
    function initTimer()
    {
        var timer = new timerDisplay($timerDisplay);

        $missionCaptureControl.find('.start-timer').on('click', function () {
            timer.startTimer();
        });

        $missionCaptureControl.find('.stop-timer').on('click', function () {
            timer.endTimer();
        });
    }

    //Init our UI
    function init()
    {
        initTimer();
        initControlListeners();
    }

    init();

});