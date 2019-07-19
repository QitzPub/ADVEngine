using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Qitz.ADVGame
{
    public class CutVO : ICutVO
    {
        IADVSpriteDataStore aDVSpriteDataStore;

        WindowVO windowVO = new WindowVO();
        public IWindowVO WindowVO => windowVO;

        //public string BgmID { get; set; }

        List<ICommandWrapVO> commands = new List<ICommandWrapVO>();
        public List<ICommandWrapVO> Commands => commands;

        BackgroundVO backgroundVO;
        public IBackgroundVO BackgroundVO => backgroundVO;

        List<CharacterVO> caracters = new List<CharacterVO>();
        public List<ICaracterVO> Caracters => caracters.Select(cv => cv as ICaracterVO).ToList();

        List<IChoiceVO> choices = new List<IChoiceVO>();
        public List<IChoiceVO> Choices => choices;

        public bool IsEmptyVO => commands.Count == 0 && windowVO.WindowCharacterName == "" && windowVO.WindowText == "";

        public int Number { get; private set; }

        public string SelTagValue => commands.FirstOrDefault(cd=>cd.SelTagValue != "") != null 
                                    ? commands.FirstOrDefault(cd => cd.SelTagValue != "").SelTagValue : "";

        public string BGMValue => commands.FirstOrDefault(cd => cd.BGMValue != "") != null
                                    ? commands.FirstOrDefault(cd => cd.BGMValue != "").BGMValue : "";

        public string BGValue => commands.FirstOrDefault(cd=>cd.BGValue != "") != null 
                                    ? commands.FirstOrDefault(cd => cd.BGValue != "").BGValue : "";

        public CutVO(int number)
        {
            this.Number = number;
        }

        public void AddCommand(ICommandWrapVO commandWrapVO)
        {
            //ここのタイミングで所持しているコマンドに応じてCharacterVOやBackGroundVOをセットする
            if (commandWrapVO.CommandHeadVO.CommandType == CommandType.CARACTER)
            {
                var characterVO = new CharacterVO(commandWrapVO);
                caracters.Add(characterVO);

            }else if (commandWrapVO.CommandHeadVO.CommandType == CommandType.BG || commandWrapVO.CommandHeadVO.CommandType == CommandType.EV)
            {
                var targetCV = commandWrapVO.CommandValues.FirstOrDefault(cv => cv.CommandValueType == CommandValueType.FILE);
                if(targetCV != null)
                {
                    this.backgroundVO = new BackgroundVO(targetCV.Value);
                }

            }

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
            BackgroundVO?.SetDataStore(aDVSpriteDataStore);
        }
    }
}