using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerController : MonoBehaviour
{
    public static float _numberHp;
    [SerializeField] private TMP_Text _hp;
    [SerializeField] private Buff _buff;
    [SerializeField] private PlayerControllerSize _playerControllerSize;
    [SerializeField] private WinTheGame _winTheGame;
    private bool lose = false;
    [SerializeField] private AudioSource m_MyAudioSource;
    private AudioSource Click_Sound;
    [SerializeField]
    private AudioMixerGroup Mixer;
    // private int _lvlIndex;

    private void Start()
    {
        //m_MyAudioSource = GetComponent<AudioSource>();

        _numberHp = 10;
        
        lose = false;
        _buff = gameObject.GetComponent<Buff>();
    }
    public void TonggleMusic()
    {
        if (progress_settings.MusicChecker==1)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);

        }

    }

    public void TonggleSounds()
    {
        if (progress_settings.SoundChecker == 1)
        {
            Mixer.audioMixer.SetFloat("SoundVolume", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("SoundVolume", -80);
        }
       
    }
    public void Update()
    {
        _hp.text = _numberHp.ToString();
        if(lose==true)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy em = other.gameObject.GetComponent<Enemy>();
            if (_numberHp > em._numberHP)
            {
                m_MyAudioSource.Play();
                _numberHp += em._numberHP;
                Destroy(other.gameObject);
                _winTheGame.CillPlupPlus();
            }
            else if (_numberHp < em._numberHP)
            {
               

                if (_buff.protect)
                {
                    _winTheGame.CillPlupPlus();
                    m_MyAudioSource.Play();
                    Destroy(other.gameObject);
                    _buff.protect = false;
                    _buff.CheckEffect();
                }
                else
                {
                  //  Destroy(gameObject);
                    lose = true;
                }
            }
           // gameObject.transform.localScale = new Vector3(_numberHp / 10, _numberHp / 10, _numberHp / 10);
            _playerControllerSize.CreateSize();
        }
        if (other.gameObject.tag == "EnemyFire")
        {
            EnemyWithFire emFire = other.gameObject.GetComponent<EnemyWithFire>();
            if (_numberHp > emFire._numberHP)
            {
                m_MyAudioSource.Play();
                _numberHp += emFire._numberHP;
                Destroy(other.gameObject);
                _winTheGame.CillPlupPlus();
            }
            else if (_numberHp < emFire._numberHP)
            {
                if (_buff.protect)
                {
                    _winTheGame.CillPlupPlus();
                    m_MyAudioSource.Play();
                    Destroy(other.gameObject);
                    _buff.protect = false;
                    _buff.CheckEffect();
                }
                else Destroy(gameObject);
            }
            //gameObject.transform.localScale = new Vector3(_numberHp / 10, _numberHp / 10, _numberHp / 10);
            _playerControllerSize.CreateSize();
        }
        if (other.gameObject.tag == "EnemyJump")
        {
            EnemyForJump emJump = other.gameObject.GetComponent<EnemyForJump>();

            if (_numberHp > emJump._numberHP)
            {
                m_MyAudioSource.Play();
                _numberHp += emJump._numberHP;
                Destroy(other.gameObject);
                _winTheGame.CillPlupPlus();
            }
            else if (_numberHp < emJump._numberHP)
            {
                if (_buff.protect)
                {
                    _winTheGame.CillPlupPlus();
                    m_MyAudioSource.Play();
                    Destroy(other.gameObject);
                    _buff.protect = false;
                    _buff.CheckEffect();
                }
                else Destroy(gameObject);
            }
            //gameObject.transform.localScale = new Vector3(_numberHp / 10, _numberHp / 10, _numberHp / 10);
            _playerControllerSize.CreateSize();
        }
        if (other.gameObject.tag == "Bullet")
        {
            _numberHp--;
            Destroy(other.gameObject);
            // gameObject.transform.localScale = new Vector3(_numberHp / 10, _numberHp / 10, _numberHp / 10);
            _playerControllerSize.CreateSize();
        }
        if (other.gameObject.tag == "Barier")
        {
            _numberHp -= 20 * _numberHp / 100;
            _numberHp = Mathf.Round(_numberHp);
            Destroy(other.gameObject);
            print(_numberHp);
        }
        if (other.gameObject.tag == "Portal")
        {
            Application.LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
        }

        if (other.gameObject.tag == "PortalBack")
        {
            Application.LoadLevel(0);
        }
    }
}
