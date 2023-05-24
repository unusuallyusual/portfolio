mergeInto(LibraryManager.library,
{
	ShowAdv : function(){
	ysdk.adv.showFullscreenAdv({
    callbacks: {
         onOpen: () => {
         SendMessage("Camera", "SoundOff");
        },
        onClose: function(wasShown) {
          // some action after close
          SendMessage("Camera", "SoundOn");
        },
        onError: function(error) {
          // some action on error
          SendMessage("Camera", "SoundOff");
        }
    }
})
	},

    AddLifeExtern : function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
          SendMessage("Camera", "SoundOff");
        },
        onRewarded: () => {
          console.log('Rewarded!');
          SendMessage("TimeHandler", "AddLife");
        },
        onClose: () => {
          console.log('Video ad closed.');
          SendMessage("Camera", "SoundOn");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
    },

});