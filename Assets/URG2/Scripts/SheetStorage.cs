using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SheetStorage : MonoBehaviour
{
    /*
     * ����
        1) ��Ʈ ������Ʈ �о y��ǥ ������� �ð� ���
        BarPerSec / 16 * ��Ʈy��ǥ = ����� �ð�

        �ճ�Ʈ�� ���
        Head y��ǥ = NoteLong�� y��ǥ
        Tail y��ǥ = NoteLong.y + tail.y�� ������ǥ
     */


    void Start()
    {

    }

    public void Save()
    {
        Sheet sheet = GameManager.Instance.sheets[GameManager.Instance.title];

        List<Note> notes = new List<Note>();
        string noteStr = string.Empty;
        float baseTime = sheet.BarPerSec / 16;
        // ��ġ ��� ���� ���� ���� ����
        int numLines = sheet.numLines;
        int median = numLines / 2;
        foreach (NoteObject note in NoteGenerator.Instance.toReleaseList)
        {
            if (!note.gameObject.activeSelf) // ��Ȱ��ȭ�Ǿ��ִٸ� ������ ��Ʈ�̹Ƿ� ����
                continue;
            
            float linePosX = note.transform.position.x;
            int findLine = 0;
            bool isEven = numLines % 2 == 0;
            for (var i = 0; i < median; i++)
            {
                if (isEven)
                {
                    if (linePosX > i && linePosX < i + 1)
                    {
                        // Positive
                        findLine = median + i;
                    }
                    else if (linePosX < -i && linePosX > -(i + 1))
                    {
                        // Negative
                        findLine = median - 1 - i;
                    }
                }
                else
                {
                    // Odd Case
                    if (linePosX > (i + 0.5f) && linePosX < (i + 1.5f))
                    {
                        // Positive
                        findLine = median + 1 + i;
                    }
                    else if (linePosX < -(i + 0.5f) && linePosX > -(i + 1.5f))
                    {
                        // Negative
                        findLine = median - 1 - i;
                    }

                    if (linePosX > -0.5f && linePosX < 0.5f)
                    {
                        // Zero
                        findLine = median;
                    }
                }
            }

            if (note is NoteShort)
            {
                NoteShort noteShort = note as NoteShort;
                int noteTime = (int)(noteShort.transform.localPosition.y * baseTime * 1000) + sheet.offset;

                notes.Add(new Note(noteTime, (int)NoteType.Short, findLine + 1, -1));
                //noteStr += $"{noteTime}, {(int)NoteType.Short}, {findLine + 1}\n";
            }
            else if (note is NoteLong)
            {
                NoteLong noteLong = note as NoteLong;
                int headTime = (int)(noteLong.transform.localPosition.y * baseTime * 1000) + sheet.offset;
                int tailTime = (int)((noteLong.transform.localPosition.y + noteLong.tail.transform.localPosition.y) * baseTime * 1000) + sheet.offset;

                notes.Add(new Note(headTime, (int)NoteType.Long, findLine + 1, tailTime));
                //noteStr += $"{headTime}, {(int)NoteType.Long}, {findLine + 1}, {tailTime}\n";
            }
        }

        notes = notes.OrderBy(a => a.time).ToList();

        foreach (Note n in notes)
        {
            switch (n.type)
            {
                case (int)NoteType.Short:
                    noteStr += $"{n.time}, {n.type}, {n.line}\n";
                    break;
                case (int)NoteType.Long:
                    noteStr += $"{n.time}, {n.type}, {n.line}, {n.tail}\n";
                    break;
            }
        }


        string writer = $"[Description]\n" +
            $"Title: {sheet.title}\n" +
            $"Artist: {sheet.artist}\n\n" +
            $"NumLines: {sheet.numLines}\n\n" +
            $"[Audio]\n" +
            $"BPM: {sheet.bpm}\n" +
            $"Offset: {sheet.offset}\n" +
            $"Signature: {sheet.signature[0]}/{sheet.signature[1]}\n\n" +
            $"[Note]\n" +
            $"{noteStr}";

        writer.TrimEnd('\r', '\n');

        string pathSheet = $"{Application.dataPath}/Sheet/{sheet.title}/{sheet.title}.sheet";
        if (File.Exists(pathSheet))
        {
            try
            {
                File.Delete(pathSheet);
            }
            catch (IOException e)
            {
                Debug.LogError(e.Message);
                return;
            }
        }

        if (!File.Exists(pathSheet))
        {
            using (FileStream fs = File.Create(pathSheet))
            {

            }
        }
        else
        {
            Debug.LogError($"{sheet.title}.sheet�� �̹� �����մϴ� !");
            return;
        }

        using (StreamWriter sw = new StreamWriter(pathSheet))
        {
            sw.Write(writer);
        }
    }
}
