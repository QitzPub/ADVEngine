using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ADVGame
{
    public class CutVO : ICutVO
    {
        IADVSpriteDataStore aDVSpriteDataStore;

        WindowVO windowVO = new WindowVO();
        public IWindowVO WindowVO => windowVO;

        public string BgmID { get; set; }

        List<ICommandWrapVO> commands = new List<ICommandWrapVO>();
        public List<ICommandWrapVO> Commands => commands;

        public IBackgroundVO BackgroundVO { get; set; }

        public List<ICaracterVO> Caracters { get; set; }

        List<IChoiceVO> choices = new List<IChoiceVO>();
        public List<IChoiceVO> Choices => choices;

        public bool IsEmptyVO => commands.Count == 0 && windowVO.WindowCharacterName == "" && windowVO.WindowText == "";

        public void AddCommand(ICommandWrapVO commandWrapVO)
        {
            commands.Add(commandWrapVO);
        }
        public void SetWindowCharacterName(string windowCharacterName)
        {
            windowVO.SetWindowCharacterName(windowCharacterName);
        }
        public void SetWindowText(string windowText)
        {
            windowVO.SetWindowText(windowText);
        }

        public void SetDataStore(IADVSpriteDataStore aDVSpriteDataStore)
        {
            this.aDVSpriteDataStore = aDVSpriteDataStore;
            Caracters.ForEach(cv => cv.SetDataStore(aDVSpriteDataStore));
            BackgroundVO.SetDataStore(aDVSpriteDataStore);
        }
    }
}