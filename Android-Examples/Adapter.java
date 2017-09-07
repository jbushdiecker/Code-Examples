package droid.application.bob.grouupproject;

import android.content.Context;
import android.support.annotation.NonNull;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import java.util.ArrayList;

public class Adapter extends ArrayAdapter<String> {
    private ArrayList<String> messages;
    private Context context;
    private String sender;

    Adapter(@NonNull Context context, String sender, @NonNull ArrayList<String> messages) {
        super(context, R.layout.user, messages);
        this.messages = messages;
        this.sender = sender;
        this.context = context;
        Log.d("ADAPTER TEST", "create adapter");
    }

    public int getItemViewType(int position){
        Log.d("ADAPTER TEST", "position: " + position);
        if (messages.get(position).startsWith("u")) {
            Log.d("ADAPTER TEST", "return 0");
            return 0;
        } else {
            Log.d("ADAPTER TEST", "return 1");
            return 1;
        }
    }

    public int getViewTypeCount(){
        return 2;
    }

    @NonNull // creates new view
    public View getView(final int position, View view, @NonNull final ViewGroup parent){
        final HoldItem item;                    // subclass to keep track of created views for reuse
        int type = getItemViewType(position);   // set type
        Log.d("ADAPTER TEST", "get view");
        // if passed view does not exist make view
        if(view == null) {
            Log.d("ADAPTER TEST", "view = null");
            LayoutInflater inflater = LayoutInflater.from(context);      // declare inflater
            if(type == 0){
                Log.d("ADAPTER TEST", "type 0");
                view = inflater.inflate(R.layout.user, null, true);             // set view with inflater
                item = new HoldItem();          // create new subclass for view
                item.message = (TextView) view.findViewById(R.id.user_mess);    // set row1 img view item
            }
            else{
                Log.d("ADAPTER TEST", "type 1");
                view = inflater.inflate(R.layout.sender, null, true);             // set view with inflater
                item = new HoldItem();          // create new subclass for view
                item.contact = (TextView) view.findViewById(R.id.sender_id);      // set row1 text view item
                item.message = (TextView) view.findViewById(R.id.sender_mess);    // set row1 img view item
            }
            view.setTag(item);              // set tag for view
        }
        // if view exists reuse
        else {
            Log.d("ADAPTER TEST", "recycle view");
            item = (HoldItem) view.getTag();                // set item to used view
            view.setTag(item);                              // set tag for view
        }
        if(type == 0){
            Log.d("ADAPTER TEST", "set user data");

            item.message.setText(messages.get(position).substring(1));          // set message
        }else{
            Log.d("ADAPTER TEST", "set contact data");
            item.contact.setText(sender);                            // set sender
            item.message.setText(messages.get(position));          // set message
        }

        item.position = position;                           // set position
        Log.d("ADAPTER TEST", "return view");
        return view;                                        // return new view
    }

    // subclass to hold view info
    private static class HoldItem{
        TextView contact;         // holds text view
        TextView message;        // holds text view

        int position;               // holds position
    }
}
