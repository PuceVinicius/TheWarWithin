using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class global_shader : MonoBehaviour
{

    public Volume global_volume;

    private ColorAdjustments ca;
    private Vignette vg;
    private DepthOfField dof;
    private SplitToning st;
    private MotionBlur mb;
    private LensDistortion ld;
    private PaniniProjection pp;
    private Bloom b;
    private FilmGrain fg;
    //private float base_saturation = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void UpdateColorAdjustment(float exposure, float contrast, Color color,
                               float hue, float saturation, bool cgdColor) {
        global_volume.profile.TryGet(out ca);
        if (exposure != 0) ca.postExposure.Override(exposure);
        if (contrast != 0) ca.contrast.Override(contrast);
        if (cgdColor) ca.colorFilter.Override(color);
        if (hue != 0) ca.hueShift.Override(hue);
        if (saturation != 0) ca.saturation.Override(saturation);
	}
    
    public void UpdateVignette(Color color, float smoothness, float roundness, bool rounded, bool cgdColor) {
        global_volume.profile.TryGet(out vg);
        if (cgdColor) vg.color.Override(color);
        if (smoothness != 0.2f) vg.smoothness.Override(smoothness);
        if (roundness != 1f) vg.roundness.Override(roundness);
        vg.rounded.Override(rounded);
	}
    
    public void UpdateDepthOfField(DepthOfFieldMode mode, float far_start, float far_end) {
        global_volume.profile.TryGet(out dof);
        dof.focusMode.Override(mode);
        dof.farFocusStart.Override(far_start);
        dof.farFocusEnd.Override(far_end);
	}
    
    public void UpdateSplitToning(Color shadow, Color highlight, bool cgdColor1, bool cgdColor2) {
        global_volume.profile.TryGet(out st);
        if (cgdColor1) st.shadows.Override(shadow);
        if (cgdColor2) st.highlights.Override(highlight);
	}
    
    public void UpdateMotionBlur(float intensity) {
        global_volume.profile.TryGet(out mb);
        mb.intensity.Override(intensity);
	}
    
    public void UpdateLensDistortion(float intensity) {
        global_volume.profile.TryGet(out ld);
        ld.intensity.Override(intensity);
	}
    
    public void UpdatePaniniProjection(float distance) {
        global_volume.profile.TryGet(out pp);
        pp.distance.Override(distance);
	}
    
    public void UpdateBloom(float intensity) {
        global_volume.profile.TryGet(out b);
        b.intensity.Override(intensity);
	}
    
    public void UpdateFilmGrain(float intensity) {
        global_volume.profile.TryGet(out fg);
        fg.intensity.Override(intensity);
	}
}
